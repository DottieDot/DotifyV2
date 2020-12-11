import { Button, FormHelperText, TextField, Typography } from '@material-ui/core'
import React, { useCallback, useMemo, useState } from 'react'
import useStyles from './style'
import * as api from '../../api/endpoints'
import { useDispatch } from 'react-redux'
import { setApiToken } from '../../store/actions/Auth'

interface Props {
  authenticating: boolean
  setAuthenticating: (authenticating: boolean) => void
}

export default ({ authenticating, setAuthenticating }: Props) => {
  const classes = useStyles()
  const [state, setState] = useState({
    username: '',
    password: '',
  })
  const [error, setError] = useState<string|null>(null)
  const dispatch = useDispatch()

  const onChange = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    setError(null)
    const name = e.target.attributes.getNamedItem('name')?.value
    if (name !== undefined) {
      setState({
        ...state,
        [name]: e.target.value
      })
    }
  }, [state, setError])

  const stateIsValid = useMemo(() => {
    return !!(state.username && state.password)
  }, [state])

  const sharedProps = {
    fullWidth: true,
    required: true,
    onChange: onChange,
    disabled: authenticating,
  }

  const authenticate = useCallback(() => {
    const fn = async () => {
      setAuthenticating(true)
      const token = await api.authenticate(state.username, state.password)
      if (token !== null) {
        dispatch(setApiToken(token))
      }
      else {
        setError('Invalid credentials.')
        setAuthenticating(false)
      }
    }
    fn()
  }, [setAuthenticating, state, dispatch])

  return (
    <form className={classes.form}>
      <TextField
        type="text"
        placeholder="JohnDoe"
        label="Username"
        name="username"
        {...sharedProps}
      />
      <FormHelperText error>{' '}</FormHelperText>
      <TextField
        type="password"
        label="Password"
        name="password"
        {...sharedProps}
      />
      <FormHelperText error>{' '}</FormHelperText>
      <div className={classes.gap} />
      <Typography 
        variant="caption" 
        className={classes.errorText} 
        gutterBottom
      >
        {error}
      </Typography>
      <Button 
        variant="contained" 
        color="primary"
        disabled={authenticating || !stateIsValid}
        onClick={authenticate}
        fullWidth
      >
        Login
      </Button>
    </form>
  )
}
