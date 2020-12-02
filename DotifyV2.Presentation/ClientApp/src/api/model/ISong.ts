import IAlbumBrief from './IAlbumBrief'
import IArtistBrief from './IArtistBrief'

export default interface ISong {
  id      : number
  name    : string
  duration: number
  album   : IAlbumBrief
  artist  : IArtistBrief
}
