import { Container, Grid, Link, makeStyles, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core'
import React, { Fragment, useCallback, useEffect, useRef, useState } from 'react'
import { useParams } from 'react-router'
import { Link as RouterLink } from 'react-router-dom'
import { getAlbum } from '../../api/endpoints'
import { Album } from '../../api/model'
import { AppBar, MediaInfoCard, SongTableRow } from '../../components'
import { useShare } from '../../hooks'

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

