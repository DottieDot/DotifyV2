import { Card, CardContent, Container, Grid, LinearProgress, Typography } from '@material-ui/core'
import React, { useState } from 'react'
import LoginForm from './LoginForm'
import RegistrationForm from './RegistrationForm'
import useStyles from './style'

export default () => {
  const classes = useStyles()
  const [authenticating, setAuthenticating] = useState(false)

  return (
    <Container fixed className={classes.container}>
      <Typography 
        component="h1" 
        variant="h4" 
        align="center" 
        gutterBottom
      >
        Dotify
      </Typography>
      <Grid container spacing={4}>
        <Grid item md={6} xs={12}>
          <Card className={classes.card}>
            <LinearProgress hidden={!authenticating} />
            <CardContent className={classes.cardContent}>
              <Typography 
                component="h2" 
                variant="h5"
                gutterBottom
              >
                Sign Up
              </Typography>
              <RegistrationForm 
                authenticating={authenticating} 
                setAuthenticating={setAuthenticating} 
              />
            </CardContent>
          </Card>
        </Grid>
        <Grid item md={6} xs={12}>
          <Card className={classes.card}>
            <LinearProgress hidden={!authenticating} />
            <CardContent className={classes.cardContent}>
              <Typography 
                component="h2" 
                variant="h5"
                gutterBottom
              >
                Login
              </Typography>
              <LoginForm 
                authenticating={authenticating} 
                setAuthenticating={setAuthenticating} 
              />
            </CardContent>
          </Card>
        </Grid>
      </Grid>
    </Container>
  )
}
