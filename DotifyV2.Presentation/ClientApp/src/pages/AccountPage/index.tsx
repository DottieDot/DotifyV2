import { Button, Container, makeStyles, Paper, Typography } from '@material-ui/core'
import React, { Fragment } from 'react'
import { AppBar, Spacing } from '../../components'
import Details from './Details'
import Password from './Password'
import Application from './Application'
import Other from './Other'

const useStyles = makeStyles(theme => ({
  paper: {
    padding: theme.spacing(2)
  },
  grid: {
    display: 'grid',
    gap: theme.spacing(2),
    [theme.breakpoints.up('xs')]: {
      gridTemplateColumns: '1fr'
    },
    [theme.breakpoints.up('md')]: {
      gridTemplateColumns: '1fr 1fr'
    }
  }
}))

export default () => {
  const classes = useStyles()

  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg">
        
        <Spacing size={2} />
        <Typography
          variant="h5"
          component="h2"
          gutterBottom
        >
          Account
        </Typography>
        <div className={classes.grid}>
          <Paper className={classes.paper}>
            <Details />
          </Paper>
          <Paper className={classes.paper}>
            <Password />
          </Paper>
        </div>
        <Spacing size={2} />
        <Typography
          variant="h5"
          component="h2"
          gutterBottom
        >
          Settings
        </Typography>
        <div className={classes.grid}>
          <Paper className={classes.paper}>
            <Application />
          </Paper>
          <Paper className={classes.paper}>
            <Other />
          </Paper>
        </div>
      </Container>
      <Spacing />
    </Fragment>
  )
}
