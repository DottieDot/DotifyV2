import { Button, ButtonGroup, Container, Grid, Link, makeStyles, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core'
import React, { Fragment, useCallback, useEffect, useRef, useState } from 'react'
import { useParams } from 'react-router'
import { Link as RouterLink } from 'react-router-dom'
import { getAlbum } from '../../api/endpoints'
import { Album } from '../../api/model'
import { AppBar, MediaInfoCard, SongTableRow } from '../../components'
import { useAuthenticatedUser, useShare } from '../../hooks'
import RenameAlbumDialog from './RenameAlbumDialog'

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

interface Params {
  album: string
}

export default () => {
  const classes = useStyles()
  const user = useAuthenticatedUser()
  const [album, setAlbum] = useState<Album | null>(null)
  const [renameAlbumDialog, setRenameAlbumDialog] = useState(false)
  const { album: albumId } = useParams<Params>()
  const stickyMediaInfoCardContainer = useRef(null)
  const share = useShare()

  useEffect(() => {
    (async () => {
      if (typeof (+albumId) !== 'number')
        return

      setAlbum(await getAlbum(+albumId))
    })()
  }, [setAlbum, albumId])

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
                    onClick={showRenameAlbumDialog}
                  >
                    Rename
                  </Button>
                  <Button
                    onClick={showRenameAlbumDialog}
                    color="secondary"
                  >
                    Delete
                  </Button>
                </ButtonGroup>
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
                    <TableCell>#</TableCell>
                    <TableCell>Name</TableCell>
                    <TableCell align="right">Duration</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {album?.songs.map(({ id, name, duration }, index) => (
                    <SongTableRow
                      key={id}
                      songNr={index + 1}
                      name={name}
                      duration={duration}
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

