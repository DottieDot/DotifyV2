import { Button, Container, Divider, Grid, makeStyles, Typography } from '@material-ui/core'
import React, { Fragment, useCallback, useEffect, useRef, useState } from 'react'
import { useParams } from 'react-router'
import { getArtist } from '../../api/endpoints'
import { AlbumResponse, Artist } from '../../api/model'
import { Album, AppBar, MediaGrid, MediaInfoCard, NotFound } from '../../components'
import { useAuthenticatedUser, useShare } from '../../hooks'
import NewAlbumDialog from './NewAlbumDialog'
import Skeleton from './Skeleton'

interface Params {
  artist: string
}

const useStyles = makeStyles(theme => ({
  container: {
    position: 'relative',
  },
  stickyMediaInfroCardContainer: {
    position: 'sticky',
    top: 75,
    zIndex: 1,
  },
  cardGridItem: {
    [theme.breakpoints.up('md')]: {
      maxWidth: 220
    }
  },
  newAlbumButton: {
    marginBottom: theme.spacing(1),
    [theme.breakpoints.down('md')]: {
      marginTop: theme.spacing(1),
    }
  }
}))

export default () => {
  const classes = useStyles()
  const user = useAuthenticatedUser()
  const [notFound, setNotFound] = useState(false)
  const [newAlbumDialog, setNewAlbumDialog] = useState(false)
  const [artist, setArtist] = useState<Artist | null>(null)
  const { artist: artistId } = useParams<Params>()
  const stickyMediaInfoCardContainer = useRef(null)
  const share = useShare()
  const loading = notFound || !artist

  useEffect(() => {
    (async () => {
      if (typeof (+artistId) !== 'number')
        return

      const artist = await getArtist(+artistId)
      if (artist !== null) {
        setArtist(artist)
      }
      else {
        setNotFound(true)
      }
    })()
  }, [artistId, setArtist, setNotFound])

  const onShare = useCallback(() => {
    if (artist) {
      share(artist.name, window.location.href)
    }
  }, [artist, share])

  const showNewAlbumDialog = useCallback(() => {
    setNewAlbumDialog(true)
  }, [setNewAlbumDialog])

  const closeNewAlbumDialog = useCallback((album: AlbumResponse | null) => {
    setNewAlbumDialog(false)
    if (album && artist) {
      setArtist({
        ...artist,
        albums: [
          ...artist.albums,
          album
        ]
      })
    }
  }, [setNewAlbumDialog, setArtist, artist])

  if (loading) {
    return (
      <Skeleton />
    )
  }

  if (notFound) {
    return (
      <NotFound
        text="Artist not found."
      />
    )
  }

  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg" className={classes.container}>
        <div 
          className={classes.stickyMediaInfroCardContainer} 
          ref={stickyMediaInfoCardContainer} 
        />
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
            {(user?.artist_id === artist?.id) && (
              <Fragment>
                <Button
                  variant="contained"
                  color="primary"
                  className={classes.newAlbumButton}
                  onClick={showNewAlbumDialog}
                  fullWidth
                >
                  New Album
                </Button>
                <NewAlbumDialog
                  open={newAlbumDialog}
                  onClose={closeNewAlbumDialog}
                />
              </Fragment>
            )}
            <Typography 
              variant="h5" 
              component="h2" 
              gutterBottom
            >
              Albums
            </Typography>
            <Divider variant="fullWidth" />
            <MediaGrid>
              {artist?.albums.map(album => (
                <Album 
                  key={album.id} 
                  id={album.id} 
                  name={album.name} 
                  coverArt={album.cover_art} 
                />
              ))}
            </MediaGrid>
          </Grid>
        </Grid>
      </Container>
    </Fragment>
  )
}
