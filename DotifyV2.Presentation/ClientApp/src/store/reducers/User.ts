import { LOGOUT } from '../model/actions/Auth'
import { SET_USER_INFO, SET_USER_USERNAME, UserAction } from '../model/actions/User'
import UserState from '../model/state/UserState'

const defaultState: UserState = null

export default (state: UserState = defaultState, action: UserAction): UserState | null => {
  switch (action.type) {
    case SET_USER_INFO:
      return {...{
        ...action.userInfo,
        likes: undefined
      }}
    case SET_USER_USERNAME:
      return state && {
        ...state,
        username: action.username
      }
    case LOGOUT:
      return defaultState
    default:
      return state
  }
}
