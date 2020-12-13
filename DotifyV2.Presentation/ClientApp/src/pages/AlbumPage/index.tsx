import { Container, Table, TableHead, TableRow, TableCell, TableBody, TableContainer, Paper, Grid, Card, CardContent, Typography, CardMedia, makeStyles, Link, Button } from '@material-ui/core'
import React, { Fragment, useCallback, useEffect, useState } from 'react'
import { useParams } from 'react-router'
import { Link as RouterLink } from 'react-router-dom'
import { getAlbum } from '../../api/endpoints'
import { Album } from '../../api/model'
import { MediaAvatar, MediaPageAppBar, SongTableRow } from '../../Components'
import copyToClipboard from 'copy-to-clipboard'
import { useDispatch } from 'react-redux'
import { showAlert } from '../../store/actions/Alerts'

const useStyles = makeStyles(theme => ({
  cover: {
    background: theme.palette.primary.main,
    paddingTop: '100%'
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
      <MediaPageAppBar
        avatar={<MediaAvatar type="album" name={null} picture={null} />}
        title={null}
      />
      <Container fixed>
        <Grid container spacing={2}>
          <Grid item lg={2} md={3} xs={12}>
            <Card>
              <CardMedia className={classes.cover}>
                
              </CardMedia>
              <CardContent>
                <Typography variant="h5" component="h1">
                  {album?.name}
                </Typography>
                <Typography variant="subtitle1" color="textSecondary" gutterBottom>
                  <Link 
                    to={`/artists/${album?.artist.id}`}
                    color="inherit"
                    component={RouterLink}
                  >
                    {album?.artist.name}
                  </Link>
                </Typography>
                <Button 
                  variant="outlined"
                  onClick={onShare}
                  fullWidth
                >
                  Share
                </Button>
              </CardContent>
            </Card>
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

