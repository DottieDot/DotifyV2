import { Button, ButtonGroup, Container, Grid, Link, makeStyles, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core'
import React, { Fragment, useCallback, useEffect, useRef, useState } from 'react'
import { useParams } from 'react-router'
import { Link as RouterLink } from 'react-router-dom'
import { getAlbum } from '../../api/endpoints'
import { Album, Song } from '../../api/model'
import { AppBar, MediaInfoCard, NotFound, SongTableRow } from '../../components'
import { useAuthenticatedUser, useShare } from '../../hooks'
import DeleteAlbumDialog from './DeleteAlbumDialog'
import NewSongDialog from './NewSongDialog'
import RenameAlbumDialog from './RenameAlbumDialog'
import Skeleton from './Skeleton'

const useStyles = makeStyles(theme => ({
  stickyMediaInfroCardContainer: {
    position: 'sticky',
    top: 75,
    zIndex: 1
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

interface Params {
  album: string
}

export default () => {
  const classes = useStyles()
  const user = useAuthenticatedUser()
  const [album, setAlbum] = useState<Album | null>(null)
  const [notFound, setNotFound] = useState(false)
  const [renameAlbumDialog, setRenameAlbumDialog] = useState(false)
  const [deleteAlbumDialog, setDeleteAlbumDialog] = useState(false)
  const [newSongDialog, setNewSongDialog] = useState(false)
  const { album: albumId } = useParams<Params>()
  const stickyMediaInfoCardContainer = useRef(null)
  const share = useShare()
  const loading = notFound || !album

  useEffect(() => {
    (async () => {
      if (typeof (+albumId) !== 'number')
        return

      const album = await getAlbum(+albumId)
      if (album !== null) {
        setAlbum(album)
      }
      else {
        setNotFound(true)
      }
    })()
  }, [setAlbum, albumId, setNotFound])

  const onShare = useCallback(() => {
    if (album) {
      share(album.name, window.location.href)
    }
  }, [album, share])

  const showRenameAlbumDialog = useCallback(() => {
    setRenameAlbumDialog(true)
  }, [setRenameAlbumDialog])

  const closeRenameAlbumDialog = useCallback((name: string | null) => {
    setRenameAlbumDialog(false)
    if (name && album) {
      setAlbum({
        ...album,
        name
      })
    }
  }, [setRenameAlbumDialog, album, setAlbum])

  const showDeleteAlbumDialog = useCallback(() => {
    setDeleteAlbumDialog(true)
  }, [setDeleteAlbumDialog])

  const closeDeleteAlbumDialog = useCallback(() => {
    setDeleteAlbumDialog(false)
  }, [setDeleteAlbumDialog])

  const showNewSongDialog = useCallback(() => {
    setNewSongDialog(true)
  }, [setNewSongDialog])

  const onDeleteSong = useCallback((songId: number) => {
    if (album) {
      setAlbum({
        ...album,
        songs: album.songs.filter(song => song.id !== songId)
      })
    }
  }, [setAlbum, album])

  const onUpdateSong = useCallback((songId: number, name: string, duration: number) => {
    if (album) {
      setAlbum({
        ...album,
        songs: album.songs.map(song => (song.id === songId ? {
          ...song,
          duration,
          name,
        } : song))
      })
    }
  }, [album, setAlbum])

  const closeNewSongDialog = useCallback((song: Song | null) => {
    setNewSongDialog(false)
    if (album && song) {
      setAlbum({
        ...album,
        songs: [
          ...album.songs,
          song,
        ]
      })
    }
  }, [setNewSongDialog, album, setAlbum])

  if (loading) {
    return (
      <Skeleton />
    )
  }

  if (notFound) {
    return (
      <NotFound 
        text="Album not found."
      />
    )
  }

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
            <MediaInfoCard
              title={album?.name ?? ''}
              subtitle={(
                <Link
                  to={`/artists/${album?.artist.id}`}
                  color="inherit"
                  component={RouterLink}
                >
                  {album?.artist.name}
                </Link>
              )}
              type="album"
              id={album?.id ?? 0}
              image={null}
              onPlay={() => { }}
              onShare={onShare}
              stickyContainer={stickyMediaInfoCardContainer}
              shareable
              playable
            />
          </Grid>
          <Grid item xs>
            {(user?.artist_id === album?.artist.id) && (
              <Fragment>
                <ButtonGroup
                  className={classes.buttonGroup}
                  variant="contained"
                  color="primary"
                  disableElevation
                  fullWidth
                >
                  <Button
                    onClick={showNewSongDialog}
                  >
                    Add Song
                  </Button>
                  <Button
                    onClick={showRenameAlbumDialog}
                  >
                    Rename
                  </Button>
                  <Button
                    onClick={showDeleteAlbumDialog}
                    color="secondary"
                  >
                    Delete
                  </Button>
                </ButtonGroup>
                <NewSongDialog
                  albumId={album?.id ?? 0}
                  open={newSongDialog}
                  onClose={closeNewSongDialog}
                />
                <DeleteAlbumDialog
                  albumId={album?.id ?? 0}
                  open={deleteAlbumDialog}
                  onClose={closeDeleteAlbumDialog}
                />
                <RenameAlbumDialog
                  albumId={album?.id ?? 0}
                  currentName={album?.name ?? ''}
                  open={renameAlbumDialog}
                  onClose={closeRenameAlbumDialog}
                />
              </Fragment>
            )}
            <TableContainer component={Paper}>
              <Table>
                <TableHead>
                  <TableRow>
                    <TableCell width={30}>#</TableCell>
                    <TableCell>Name</TableCell>
                    <TableCell align="right">Duration</TableCell>
                    <TableCell />
                  </TableRow>
                </TableHead>
                <TableBody>
                  {album?.songs.map(({ id, name, duration }, index) => (
                    <SongTableRow
                      key={id}
                      songNr={index + 1}
                      name={name}
                      duration={duration}
                      songId={id}
                      management={user?.artist_id === album?.artist.id}
                      onSongDeleted={onDeleteSong}
                      onSongUpdated={onUpdateSong}
                    />
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          </Grid>
        </Grid>
      </Container>
    </Fragment>
  )
}
