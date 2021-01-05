import { UserInfo } from '../../../api/model'
import { Logout } from './Auth'

export const SET_USER_INFO = 'SET_USER_INFO'
export const SET_USER_USERNAME = 'SET_USER_USERNAME'

export interface SetUserInfo {
  type: typeof SET_USER_INFO
  userInfo: UserInfo
}

export interface SetUserUsername {
  type: typeof SET_USER_USERNAME
  username: string
}

export type UserAction = SetUserInfo | Logout | SetUserUsername
