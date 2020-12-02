import { Button, TextField } from '@material-ui/core'
import React, { useCallback, useState } from 'react'
import useStyles from './style'

interface Props {
  authenticating: boolean
  setAuthenticating: (authenticating: boolean) => void
}

export default ({ authenticating, setAuthenticating }: Props) => {
  const classes = useStyles()
  const [state, setState] = useState({
    username: '',
    password: '',
    confirmPassword: ''
  })

  const onChange = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    const name = e.target.attributes.getNamedItem('name')?.value
    if (name !== undefined) {
      setState({
        ...state,
        [name]: e.target.value
      });
    }
  }, [state])

  const sharedProps = {
    fullWidth: true,
    required: true,
    onChange: onChange,
    disabled: authenticating,
  }

  const signUp = useCallback(() => {
    const fn = async () => {
      setAuthenticating(true)
      // Authenticate
    }
    fn()
  }, [setAuthenticating, state])

  return (
    <form className={classes.form}>
      <TextField
        type="text"
        placeholder="JohnDoe"
        label="Username"
        name="email"
        {...sharedProps}
      />
      <TextField
        type="password"
        label="Password"
        name="password"
        {...sharedProps}
      />
      <TextField 
        type="password"
        label="Confirm Password"
        name="confirmpassword"
        {...sharedProps}
      />
      <div className={classes.gap} />
      <Button 
        variant="contained" 
        color="primary"
        disabled={authenticating}
        onClick={signUp}
        fullWidth
      >
        Create Account
      </Button>
    </form>
  )
}
