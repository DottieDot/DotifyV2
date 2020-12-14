import { AppBar, Button, Container, makeStyles, Toolbar, Typography } from '@material-ui/core'
import React from 'react'
import AddPropsWhenScrolled from './AddPropsWhenScrolled'

const useStyles = makeStyles(theme => ({
  appBar: {
    transition: 'box-shadow 300ms cubic-bezier(0.4, 0, 0.2, 1) 0ms, background 300ms cubic-bezier(0.4, 0, 0.2, 1) 0ms',
    background: theme.palette.background.paper,
    color: theme.palette.text.primary,
    marginBottom: theme.spacing(2),
  },
  restingAppbar: {
    background: theme.palette.background.default,
  },
  toolbar: {
    paddingRight: 0,
    paddingLeft: 0,
    display: 'flex',
    flexDirection: 'row'
  },
  gap: {
    flex: 1,
  }
}))

export default () => {
  const classes = useStyles()

  return (
    <AddPropsWhenScrolled props={{ elevation: 4, className: classes.appBar }}>
      <AppBar elevation={0} className={`${classes.restingAppbar} ${classes.appBar}`} position="sticky">
        <Container maxWidth="lg">
          <Toolbar className={classes.toolbar}>
            <Typography variant="h6" component="h1">
              Dotify
            </Typography>
            <div className={classes.gap} />
            <Button color="inherit">Home</Button>
            <Button color="inherit">Playlists</Button>
          </Toolbar>
        </Container>
      </AppBar>
    </AddPropsWhenScrolled>
  )
}
