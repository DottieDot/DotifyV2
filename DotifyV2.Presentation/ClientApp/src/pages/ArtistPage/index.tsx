import { Container, Divider, Grid, makeStyles, Typography } from '@material-ui/core'
import React, { Fragment, useEffect, useRef, useState } from 'react'
import { useParams } from 'react-router'
import { getArtist } from '../../api/endpoints'
import { Artist } from '../../api/model'
import { Album, AppBar, MediaInfoCard } from '../../Components'

interface Params {
  artist: string
}

const useStyles = makeStyles(theme => ({
  grid: {
    display: 'grid',
    gap: theme.spacing(2),
    gridTemplateColumns: 'repeat(auto-fill, minmax(160px, 1fr))',
    marginTop: theme.spacing(),
    marginBottom: theme.spacing(2),
  },
  stickyMediaInfroCardContainer: {
    position: 'sticky',
    top: 75
  },
  cardGridItem: {
    [theme.breakpoints.up('md')]: {
      maxWidth: 220
    }
  }
}))

export default () => {
  const classes = useStyles()
  const [artist, setArtist] = useState<Artist | null>(null)
  const { artist: artistId } = useParams<Params>()
  const stickyMediaInfoCardContainer = useRef(null)

  useEffect(() => {
    (async () => {
      if (typeof (+artistId) !== 'number')
        return

      setArtist(await getArtist(+artistId))
    })()
  }, [artistId, setArtist])

  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg">
        <div className={classes.stickyMediaInfroCardContainer} ref={stickyMediaInfoCardContainer} />
        <Grid container spacing={2}>
          <Grid item md xs={12} className={classes.cardGridItem}>
            <MediaInfoCard
              title={artist?.name ?? ''}
              image={null}
              liked={false}
              onLike={() => { }}
              onPlay={() => { }}
              onShare={() => { }}
              stickyContainer={stickyMediaInfoCardContainer}
              likeable
              shareable
            />
          </Grid>
          <Grid item xs>
            <Typography variant="h5" component="h2" gutterBottom>Albums</Typography>
            <Divider variant="fullWidth" />
            <div className={classes.grid}>
              {artist?.albums.map(album => <Album key={album.id} name={album.name} coverArt={album.cover_art} />)}
            </div>
          </Grid>
        </Grid>
      </Container>
    </Fragment>
  )
}
