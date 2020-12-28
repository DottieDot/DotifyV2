import { LOGOUT } from '../model/actions/Auth'
import { SET_USER_INFO, UserAction } from '../model/actions/User'
import UserState from '../model/state/UserState'

const defaultState: UserState = null

export default (state: UserState = defaultState, action: UserAction): UserState | null => {
  switch (action.type) {
    case SET_USER_INFO:
      return {...{
        ...action.userInfo,
        likes: undefined
      }}
    case LOGOUT:
      return defaultState
    default:
      return state
  }
}
