import ArtistDescription from './ArtistDescription'
import SongDescription from './SongDescription'

export default interface AlbumResponse {
  id: number
  name: string
  cover_art: string
  songs: SongDescription[]
  artist: ArtistDescription
}
