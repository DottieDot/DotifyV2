import AlbumDescription from './AlbumDescription'

export default interface ArtistResponse {
  id: number
  name: string
  duration: number
  file_name: string
  album: AlbumDescription
}
