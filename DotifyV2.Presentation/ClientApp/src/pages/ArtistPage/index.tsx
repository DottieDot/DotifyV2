import { Container, Divider, Grid, makeStyles, Typography } from '@material-ui/core'
import React, { Fragment, useCallback, useEffect, useRef, useState } from 'react'
import { useParams } from 'react-router'
import { getArtist } from '../../api/endpoints'
import { Artist } from '../../api/model'
import { Album, AppBar, MediaInfoCard } from '../../Components'
import { useShare } from '../../hooks'

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
  const share = useShare()

  useEffect(() => {
    (async () => {
      if (typeof (+artistId) !== 'number')
        return

      setArtist(await getArtist(+artistId))
    })()
  }, [artistId, setArtist])

  const onShare = useCallback(() => {
    if (artist) {
      share(artist.name, window.location.href)
    }
  }, [artist, share])

  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg">
        <div className={classes.stickyMediaInfroCardContainer} ref={stickyMediaInfoCardContainer} />
        <Grid container spacing={2}>
          <Grid item md xs={12} className={classes.cardGridItem}>
            <MediaInfoCard
              title={artist?.name ?? ''}
              type="artist"
              id={artist?.id ?? 0}
              image={null}
              onShare={onShare}
              stickyContainer={stickyMediaInfoCardContainer}
              shareable
            />
          </Grid>
          <Grid item xs>
            <Typography variant="h5" component="h2" gutterBottom>Albums</Typography>
            <Divider variant="fullWidth" />
            <div className={classes.grid}>
              {artist?.albums.map(album => <Album key={album.id} id={album.id} name={album.name} coverArt={album.cover_art} />)}
            </div>
          </Grid>
        </Grid>
      </Container>
    </Fragment>
  )
}
