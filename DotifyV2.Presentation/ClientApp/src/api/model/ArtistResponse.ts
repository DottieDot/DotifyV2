import AlbumDescription from './AlbumDescription'

export default interface ArtistResponse {
  id: number
  name: string
  picture: string
  albums: AlbumDescription[]
}
