import { Container, Divider, Grid, makeStyles, Typography } from '@material-ui/core'
import React, { Fragment, useRef } from 'react'
import { AlbumSkeleton, AppBar, MediaGrid, MediaInfoCardSkeleton } from '../../components'

const useStyles = makeStyles(theme => ({
  stickyMediaInfroCardContainer: {
    position: 'sticky',
    top: 75
  },
  cardGridItem: {
    [theme.breakpoints.up('md')]: {
      maxWidth: 220
    }
  },
  buttonGroup: {
    marginBottom: theme.spacing(1),
    [theme.breakpoints.down('md')]: {
      marginTop: theme.spacing(1),
    }
  },
}))

export default () => {
  const classes = useStyles()
  const stickyMediaInfoCardContainer = useRef(null)

  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg">
        <div
          className={classes.stickyMediaInfroCardContainer}
          ref={stickyMediaInfoCardContainer}
        />
        <Grid container spacing={2}>
          <Grid item className={classes.cardGridItem} md xs={12}>
            <MediaInfoCardSkeleton
              stickyContainer={stickyMediaInfoCardContainer}
              shareable
            />
          </Grid>
          <Grid item xs>
            <Typography
              variant="h5"
              component="h2"
              gutterBottom
            >
              Albums
            </Typography>
            <Divider variant="fullWidth" />
            <MediaGrid>
              <AlbumSkeleton index={0} />
              <AlbumSkeleton index={1} />
              <AlbumSkeleton index={2} />
            </MediaGrid>
          </Grid>
        </Grid>
      </Container>
    </Fragment>
  )
}
