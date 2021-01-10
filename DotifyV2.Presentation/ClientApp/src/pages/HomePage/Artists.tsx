import { Button, Divider, Typography } from '@material-ui/core'
import React, { Fragment, useCallback, useEffect, useState } from 'react'
import * as endpoints from '../../api/endpoints'
import { ArtistDescritpion } from '../../api/model'
import { Artist, MediaGrid } from '../../components'

const LOAD_COUNT = 1

export default () => {
  const [artists, setArtists] = useState<ArtistDescritpion[] | null>(null)
  const [loading, setLoading] = useState(false)
  const [loadedAll, setLoadedAll] = useState(false)

  const loadArtists = useCallback(() => {
    if (loading || loadedAll)
      return
    setLoading(true);
    (async () => {
      const result = await endpoints.indexArtists(artists?.length ?? 0, LOAD_COUNT)
      if (result.length) {
        setArtists([
          ...(artists ?? []),
          ...result,
        ])
      }
      setLoadedAll(result.length !== LOAD_COUNT)
      setLoading(false)
    })()
  }, [artists, setArtists, setLoading, loading, loadedAll, setLoadedAll])

  useEffect(() => {
    if (artists === null) {
      loadArtists()
    }
  }, [loadArtists, artists, setArtists])

  if (artists === null) {
    return (
      <h1>Loading!</h1>
    )
  }

  return (
    <Fragment>
      <Typography
        variant="h5"
        component="h2"
        gutterBottom
      >
        Artists
      </Typography>
      <Divider variant="fullWidth" />
      <MediaGrid horizontal>
        {artists.map(artist => (
          <Artist
            key={artist.id}
            id={artist.id}
            name={artist.name}
            picture={artist.picture}
          />
        ))}
        {!loadedAll && (
          <Button
            onClick={loadArtists}
            disabled={loading}
          >
            Load Next
          </Button>
        )}
      </MediaGrid>
    </Fragment>
  )
}
