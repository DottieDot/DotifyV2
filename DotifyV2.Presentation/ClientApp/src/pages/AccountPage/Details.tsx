import { Button, Divider, FormHelperText, TextField, Typography } from '@material-ui/core'
import { useFormik } from 'formik'
import React, { Fragment, useCallback, useEffect } from 'react'
import { Spacing } from '../../components'
import { useAuthenticatedUser } from '../../hooks'
import * as Yup from 'yup'
import * as endpoints from '../../api/endpoints'
import { useDispatch } from 'react-redux'
import { setUserUsername } from '../../store/actions/User'
import { showAlert } from '../../store/actions/Alerts'

export default () => {
  const dispatch = useDispatch()
  const user = useAuthenticatedUser()
  const formik = useFormik({
    initialValues: {
      username: '',
      password: '',
    },
    validationSchema: Yup.object({
      username: Yup.string()
        .max(24, 'Must bebelow 24 characters')
        .matches(/^[a-zA-Z0-9]+$/, 'Username must be alphanumerical')
        .trim()
        .required('Required'),
      password: Yup.string()
        .required('Required'),
    }),
    onSubmit: async (values, { setSubmitting, resetForm, setFieldError }) => {
      const success = await endpoints.changeUsername(values.username, values.password)
      if (success) {
        resetForm()
        dispatch(showAlert('Username updated', 'success'))
        dispatch(setUserUsername(values.username))
      }
      else {
        dispatch(showAlert('Failed to change username', 'error'))
        setFieldError('password', 'Wrong password')
      }
      setSubmitting(false)
    },
    validateOnMount: true,
  })

  useEffect(() => {
    if (!formik.values['username']) {
      formik.setFieldValue('username', user?.username)
    }
  }, [user])

  const sharedProps = useCallback((name: 'username' | 'password') => ({
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
        Details
      </Typography>
      <Divider />
      <Spacing size={2} />
      <form onSubmit={formik.handleSubmit}>
        <TextField
          type="text"
          placeholder={user?.username ?? ''}
          label="Username"
          variant="outlined"
          {...sharedProps('username')}
        />
        <FormHelperText error>
          {(formik.touched.username && formik.errors.username) || ' '}
        </FormHelperText>
        <Spacing />
        <TextField
          type="password"
          label="Password"
          variant="outlined"
          {...sharedProps('password')}
        />
        <FormHelperText error>
          {(formik.touched.password && formik.errors.password) || ' '}
        </FormHelperText>
        <Spacing />
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
