import { SetUserInfo } from './User'
import { Logout } from './Auth'
import { MediaTypes } from '../../../common'

export const ADD_LIKE = 'ADD_LIKE'
export const REMOVE_LIKE = 'REMOVE_LIKE'

export interface AddLike {
  type: typeof ADD_LIKE
  mediaType: MediaTypes
  id: number
}

export interface RemoveLike {
  type: typeof REMOVE_LIKE
  mediaType: MediaTypes
  id: number
}

export type LikesAction = SetUserInfo | Logout | AddLike | RemoveLike
