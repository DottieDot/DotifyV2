import { AuthActions, LOGOUT, SET_API_TOKEN } from '../model/actions/Auth'
import { AuthState } from '../model/state'

const defaultState: AuthState = {
  
}

export default (state: AuthState = defaultState, action: AuthActions): AuthState => {
  switch (action.type) {
    case SET_API_TOKEN:
      return {
        ...state,
        apiToken: action.apiToken
      }
    case LOGOUT:
      return {
        ...state,
        apiToken: undefined,
      }
    default:
      return state
  }
}
