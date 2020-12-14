import { Container, Grid, Link, makeStyles, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core'
import copyToClipboard from 'copy-to-clipboard'
import React, { Fragment, useCallback, useEffect, useRef, useState } from 'react'
import { useDispatch } from 'react-redux'
import { useParams } from 'react-router'
import { Link as RouterLink } from 'react-router-dom'
import { getAlbum } from '../../api/endpoints'
import { Album } from '../../api/model'
import { AppBar, MediaInfoCard, SongTableRow } from '../../Components'
import { showAlert } from '../../store/actions/Alerts'

const useStyles = makeStyles(theme => ({
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

interface Params {
  album: string
}

export default () => {
  const classes = useStyles()
  const [album, setAlbum] = useState<Album | null>(null)
  const { album: albumId } = useParams<Params>()
  const dispatch = useDispatch()
  const stickyMediaInfoCardContainer = useRef(null)

  useEffect(() => {
    (async () => {
      if (typeof (+albumId) !== 'number')
        return

      setAlbum(await getAlbum(+albumId))
    })()
  }, [setAlbum, albumId])

  const onShare = useCallback(() => {
    if (navigator.share) {
      navigator.share({
        title: album?.name,
        url: window.location.href
      })
    }
    else {
      copyToClipboard(window.location.href)
      dispatch(showAlert('Link copied to clipboard', 'success'))
    }
  }, [album, dispatch])

  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg">
        <div className={classes.stickyMediaInfroCardContainer} ref={stickyMediaInfoCardContainer} />
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
              image={null}
              liked={false}
              onLike={() => { }}
              onPlay={() => { }}
              onShare={onShare}
              stickyContainer={stickyMediaInfoCardContainer}
              likeable
              shareable
            />
          </Grid>
          <Grid item xs>
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

