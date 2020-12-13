import { Container, Divider, makeStyles, Typography } from '@material-ui/core'
import React, { Fragment, useEffect, useState } from 'react'
import { useParams } from 'react-router'
import { getArtist } from '../../api/endpoints'
import { Artist } from '../../api/model'
import { Album, MediaAvatar, MediaPageAppBar } from '../../Components'

interface Params {
  artist: string
}

const useStyles = makeStyles(theme => ({
  grid: {
    display: 'grid',
    gap: theme.spacing(2),
    gridTemplateColumns: 'repeat(auto-fill, minmax(200px, 1fr))',
    marginTop: theme.spacing(),
    marginBottom: theme.spacing(2),
  }
}))

export default () => {
  const classes = useStyles()
  const [artist, setArtist] = useState<Artist | null>(null)
  const { artist: artistId } = useParams<Params>()

  useEffect(() => {
    (async () => {
      if (typeof (+artistId) !== 'number')
        return

      setArtist(await getArtist(+artistId))
    })()
  }, [artistId, setArtist])

  return (
    <Fragment>
      <MediaPageAppBar
        avatar={<MediaAvatar type="artist" name={artist?.name} picture={artist?.picture} />}
        title={artist?.name}
      />
      <Container fixed>
        <Typography variant="h5" component="h2" gutterBottom>Albums</Typography>
        <Divider variant="fullWidth" />
        <div className={classes.grid}>
          {artist?.albums.map(album => <Album key={album.id} name={album.name} coverArt={album.cover_art} />)}
        </div>
      </Container>
    </Fragment>
  )
}
