import { SetApiToken, Logout, SET_API_TOKEN, LOGOUT } from '../model/actions/Auth'

export const setApiToken = (token: string): SetApiToken => ({
  type: SET_API_TOKEN,
  apiToken: token,
})

export const logout = (): Logout => ({
  type: LOGOUT,
})
