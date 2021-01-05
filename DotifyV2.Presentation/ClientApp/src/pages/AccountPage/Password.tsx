import { Button, Divider, FormHelperText, TextField, Typography } from '@material-ui/core'
import { useFormik } from 'formik'
import React, { Fragment, useCallback } from 'react'
import { useDispatch } from 'react-redux'
import { Spacing } from '../../components'
import { useAuthenticatedUser } from '../../hooks'
import * as endpoints from '../../api/endpoints'
import * as Yup from 'yup'
import { showAlert } from '../../store/actions/Alerts'

export default () => {
  const dispatch = useDispatch()
  const user = useAuthenticatedUser()
  const formik = useFormik({
    initialValues: {
      currentPassword: '',
      newPassword: '',
      confirmNewPassword: '',
    },
    validationSchema: Yup.object({
      currentPassword: Yup.string()
        .required('Required'),
      newPassword: Yup.string()
        .max(80, 'Must be below 80 characters')
        .min(8, 'Must be at least 8 characters long')
        .matches(/[a-z]/g, 'Must contain at least 1 lower case characer')
        .matches(/[A-Z]/g, 'Must contain at least 1 upper case characer')
        .matches(/[0-9]/g, 'Must contain at least 1 numeric characer')
        .required('Required'),
      confirmNewPassword: Yup.string()
        .oneOf([Yup.ref('newPassword')], 'Passwords do not match')
        .required('Required'),
    }),
    onSubmit: async (values, { setSubmitting, resetForm, setFieldError }) => {
      const success = await endpoints.changePassword(values.currentPassword, values.newPassword)
      if (success) {
        dispatch(showAlert('Password updated', 'success'))
        resetForm()
      }
      else {
        dispatch(showAlert('Failed to change password', 'error'))
        setFieldError('currentPassword', 'Wrong password')
      }

      setSubmitting(false)
    }
  })

  const sharedProps = useCallback((name: 'currentPassword' | 'newPassword' | 'confirmNewPassword') => ({
    fullWidth: true,
    required: true,
    name: name,
    onChange: formik.handleChange,
    onBlur: formik.handleBlur,
    value: formik.values[name],
    disabled: formik.isSubmitting,
    error: !!(formik.touched[name] && formik.errors[name])
  }), [formik])

  return (
    <Fragment>
      <Typography
        variant="h6"
        component="h3"
      >
        Password
      </Typography>
      <Divider />
      <Spacing size={2} />
      <form onSubmit={formik.handleSubmit}>
        <TextField
          type="password"
          label="Current password"
          variant="outlined"
          {...sharedProps('currentPassword')}
        />
        <FormHelperText error>
          {(formik.touched.currentPassword && formik.errors.currentPassword) || ' '}
        </FormHelperText>
        <Spacing />
        <TextField
          type="password"
          label="Current password"
          variant="outlined"
          {...sharedProps('newPassword')}
        />
        <FormHelperText error>
          {(formik.touched.newPassword && formik.errors.newPassword) || ' '}
        </FormHelperText>
        <Spacing />
        <TextField
          type="password"
          label="Current password"
          variant="outlined"
          {...sharedProps('confirmNewPassword')}
        />
        <FormHelperText error>
          {(formik.touched.confirmNewPassword && formik.errors.confirmNewPassword) || ' '}
        </FormHelperText>
        <Spacing size={2} />
        <Button
          type="submit"
          variant="contained"
          color="primary"
          disabled={!formik.isValid || formik.isSubmitting}
          fullWidth
        >
          Save
        </Button>
      </form>
    </Fragment>
  )
}
