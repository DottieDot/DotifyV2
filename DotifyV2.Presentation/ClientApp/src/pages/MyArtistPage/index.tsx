import { Container, Fab, makeStyles } from '@material-ui/core'
import { Add as AddIcon } from '@material-ui/icons'
import React, { Fragment } from 'react'
import { AppBar, MediaGrid } from '../../components'

const useStyles = makeStyles(theme => ({
  container: {
    position: 'relative',
    minHeight: 400,
  },
  fab: {
    position: 'absolute',
    bottom: theme.spacing(2),
    right: theme.spacing(2),
  },
}))

export default () => {
  const classes = useStyles()

  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg" className={classes.container}>
        <MediaGrid>

        </MediaGrid>
        <Fab
          variant="extended"
          color="primary"
          className={classes.fab}
        >
          <AddIcon />
          New Album
        </Fab>
      </Container>
    </Fragment>
  )
}
