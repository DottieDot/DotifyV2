import { removePropFromObject } from '../../common'
import { LOGOUT } from '../model/actions/Auth'
import { ADD_LIKE, LikesAction, REMOVE_LIKE } from '../model/actions/Likes'
import { SET_USER_INFO } from '../model/actions/User'
import LikesState from '../model/state/LikesState'

const likeArrayReducer = (accumulator: {[key: number]: number}, id: number) => {
  accumulator[id] = id
  return accumulator
}

const defaultState: LikesState = {
  likedSongs: [],
  likedAlbums: [],
  likedArtists: [],
}

export default (state: LikesState = defaultState, action: LikesAction) => {
  switch (action.type) {
    case ADD_LIKE:
      switch (action.mediaType) {
        case 'song':
          return {
            ...state,
            likedSongs: { ...state.likedSongs, [action.id]: action.id }
          }
        case 'album':
          return {
            ...state,
            likedAlbums: { ...state.likedAlbums, [action.id]: action.id }
          }
        case 'artist':
          return {
            ...state,
            likedArtists: { ...state.likedArtists, [action.id]: action.id }
          }
        default:
          return state
      }
    case REMOVE_LIKE:
      switch (action.mediaType) {
        case 'song':
          return {
            ...state,
            likedSongs: removePropFromObject(state.likedSongs, action.id),
          }
        case 'album':
          return {
            ...state,
            likedAlbums: removePropFromObject(state.likedAlbums, action.id),
          }
        case 'artist':
          return {
            ...state,
            likedArtists: removePropFromObject(state.likedArtists, action.id),
          }
        default:
          return state
      }
    case SET_USER_INFO:
      return {
        ...state,
        likedSongs: action.userInfo.likes.songs.reduce(likeArrayReducer, {}),
        likedAlbums: action.userInfo.likes.albums.reduce(likeArrayReducer, {}),
        likedArtists: action.userInfo.likes.artists.reduce(likeArrayReducer, {}),
      }
    case LOGOUT:
      return defaultState
    default:
      return state
  }
}
