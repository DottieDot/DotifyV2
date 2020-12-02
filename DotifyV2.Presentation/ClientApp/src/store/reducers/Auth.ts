import { setApiToken } from '../../api/apiRequest'
import { AuthActions, CLEAR_API_TOKEN, SET_API_TOKEN } from '../model/actions/Auth'
import { AuthState } from '../model/state'

const defaultState: AuthState = {
  
}

export default (state: AuthState = defaultState, action: AuthActions): AuthState => {
  switch (action.type) {
    case SET_API_TOKEN:
      setApiToken(action.apiToken)
      return {
        ...state,
        apiToken: action.apiToken
      }
    case CLEAR_API_TOKEN:
      setApiToken(undefined)
      return {
        ...state,
        apiToken: undefined
      }
    default:
      return state
  }
}
