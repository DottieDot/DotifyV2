import { Container } from '@material-ui/core'
import React, { Fragment, useCallback } from 'react'
import { Album, AppBar, Artist, Spacing } from '../../components'
import Section from './Section'
import * as eindpoints from '../../api/endpoints'
import { ArtistDescritpion } from '../../api/model'

export default () => {
  const loadArtists = useCallback((offset: number, count: number) => (
    eindpoints.indexArtists(offset, count)
  ), [])

  const renderArtist = useCallback((artist: ArtistDescritpion) => (
    <Artist
      key={artist.id}
      id={artist.id}
      name={artist.name}
      picture={artist.picture}
    />
  ), [])

  const renderAlbum = useCallback((album: ArtistDescritpion) => (
    <Album
      key={album.id}
      id={album.id}
      name={album.name}
      coverArt={album.picture}
    />
  ), [])

  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg">
        <Section 
          title="Artists" 
          load={loadArtists}
          renderItem={renderArtist}
        />
        <Spacing />
        <Section 
          title="Albums" 
          load={loadArtists}
          renderItem={renderAlbum}
        />
        <Spacing />
      </Container>
    </Fragment>
  )
}
