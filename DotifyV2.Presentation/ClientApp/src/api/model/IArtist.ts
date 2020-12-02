import IAlbumBrief from './IAlbumBrief'

export default interface IArtist {
  id     : number
  name   : string
  picture: string
  albums : IAlbumBrief
}
