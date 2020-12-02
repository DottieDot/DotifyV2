import IArtistBrief from './IArtistBrief'
import ISongBrief from './ISongBrief'

export default interface IAlbum {
  id         : number
  artist     : IArtistBrief
  name       : string
  cover_art  : string
  released_at: string
  songs      : ISongBrief
}
