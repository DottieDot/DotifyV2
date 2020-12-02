import { Button, TextField } from '@material-ui/core'
import React, { useState } from 'react'
import useStyles from './style'

export default () => {
  const classes = useStyles()
  const [state, setState] = useState({
    email: '',
    name: '',
    password: '',
    confirmPassword: ''
  })

  const onChange = React.useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
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
  }

  return (
    <form className={classes.form}>
      <TextField
        type="email"
        placeholder="john.doe@example.com"
        label="Email address"
        name="email"
        {...sharedProps}
      />
      <TextField
        type="text"
        placeholder="John Doe"
        label="Name"
        name="name"
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
        fullWidth
      >
        Create Account
      </Button>
    </form>
  )
}
