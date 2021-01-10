import { Container } from '@material-ui/core'
import React, { Fragment, useCallback } from 'react'
import { Album, AlbumSkeleton, AppBar, Artist, ArtistSkeleton, Spacing } from '../../components'
import Section from './Section'
import * as eindpoints from '../../api/endpoints'
import { AlbumDescription, ArtistDescritpion } from '../../api/model'

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

  const renderArtistSkeleton = useCallback((index: number) => (
    <ArtistSkeleton key={index} index={index} />
  ), [])

  const loadAlbums = useCallback((offset: number, count: number) => (
    eindpoints.indexAlbums(offset, count)
  ), [])

  const renderAlbum = useCallback((album: AlbumDescription) => (
    <Album
      key={album.id}
      id={album.id}
      name={album.name}
      coverArt={album.cover_art}
    />
  ), [])

  const renderAlbumSkeleton = useCallback((index: number) => (
    <AlbumSkeleton key={index} index={index} />
  ), [])

  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg">
        <Section 
          title="Artists" 
          load={loadArtists}
          renderItem={renderArtist}
          renderSkeleton={renderArtistSkeleton}
        />
        <Spacing />
        <Section 
          title="Albums" 
          load={loadAlbums}
          renderItem={renderAlbum}
          renderSkeleton={renderAlbumSkeleton}
        />
        <Spacing />
      </Container>
    </Fragment>
  )
}
