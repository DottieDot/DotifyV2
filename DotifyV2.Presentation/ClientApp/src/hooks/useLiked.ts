import { MediaTypes } from '../common'
import { useTypedSelector } from '../store'

export default (type: MediaTypes, id: number): boolean => 
  useTypedSelector(state => {
    switch (type) {
      case 'song':
        return !!state.Likes.likedSongs[id]
      case 'album':
        return !!state.Likes.likedAlbums[id]
      case 'artist':
        return !!state.Likes.likedArtists[id]
    }
  })
