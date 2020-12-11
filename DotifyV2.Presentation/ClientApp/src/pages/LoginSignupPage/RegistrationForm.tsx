import { Button, FormHelperText, TextField } from '@material-ui/core'
import { useFormik } from 'formik'
import React, { useCallback } from 'react'
import useStyles from './style'
import * as Yup from 'yup'
import * as endpoints from '../../api/endpoints'
import { useDispatch } from 'react-redux'
import { setApiToken } from '../../store/actions/Auth'

interface Props {
  authenticating: boolean
  setAuthenticating: (authenticating: boolean) => void
}

export default ({ authenticating, setAuthenticating }: Props) => {
  const classes = useStyles()
  const dispatch = useDispatch()
  const formik = useFormik({
    initialValues: {
      username: '',
      password: '',
      confirmPassword: ''
    },
    validationSchema: Yup.object({
      username: Yup.string()
        .max(24, 'Must bebelow 24 characters')
        .matches(/^[a-zA-Z0-9]+$/, 'Username must be alphanumerical')
        .trim()
        .required('Required'),
      password: Yup.string()
        .max(80, 'Must be below 80 characters')
        .min(8, 'Must be at least 8 characters long')
        .matches(/[a-z]/g, 'Must contain at least 1 lower case characer')
        .matches(/[A-Z]/g, 'Must contain at least 1 upper case characer')
        .matches(/[0-9]/g, 'Must contain at least 1 numeric characer')
        .required('Required'),
      confirmPassword: Yup.string()
        .oneOf([Yup.ref('password')], 'Passwords do not match')
        .required('Required'),
    }),
    onSubmit: async (values, { setSubmitting }) => {
      setAuthenticating(true)
      const apiToken = await endpoints.signUp(values.username.trim(), values.password)
      if (apiToken !== null) {
        dispatch(setApiToken(apiToken))
      }
      else {
        setSubmitting(false)
      }
    },
    validateOnMount: true,
  })

  const sharedProps = useCallback((name: 'username' | 'password' | 'confirmPassword') => ({
    fullWidth: true,
    required: true,
    name: name,
    onChange: formik.handleChange,
    onBlur: formik.handleBlur,
    value: formik.values[name],
    disabled: authenticating || formik.isSubmitting,
    error: !!(formik.touched[name] && formik.errors[name])
  }), [formik, authenticating])

  return (
    <form className={classes.form} onSubmit={formik.handleSubmit}>
      <TextField
        type="text"
        placeholder="JohnDoe"
        label="Username"
        {...sharedProps('username')}
      />
      <FormHelperText error>
        {(formik.touched.username && formik.errors.username) || ' '}
      </FormHelperText>
      <TextField
        type="password"
        label="Password"
        {...sharedProps('password')}
      />
      <FormHelperText error>
        {(formik.touched.password && formik.errors.password) || ' '}
      </FormHelperText>
      <TextField
        type="password"
        label="Confirm Password"
        {...sharedProps('confirmPassword')}
      />
      <FormHelperText error>
        {(formik.touched.confirmPassword && formik.errors.confirmPassword) || ' '}
      </FormHelperText>
      <div className={classes.gap} />
      <Button
        variant="contained"
        color="primary"
        disabled={authenticating || !formik.isValid || formik.isSubmitting}
        type="submit"
        fullWidth
      >
        Create Account
      </Button>
    </form>
  )
}
