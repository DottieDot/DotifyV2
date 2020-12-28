import { UserInfo } from '../../../api/model'
import { Logout } from './Auth'

export const SET_USER_INFO = 'SET_USER_INFO'

export interface SetUserInfo {
  type: typeof SET_USER_INFO,
  userInfo: UserInfo,
}

export type UserAction = SetUserInfo | Logout
