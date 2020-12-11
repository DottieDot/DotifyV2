export const SET_API_TOKEN = 'SET_API_TOKEN'
export const LOGOUT = 'CLEAR_API_TOKEN'

export interface SetApiToken {
  type: typeof SET_API_TOKEN
  apiToken: string
}

export interface Logout {
  type: typeof LOGOUT
}

export type AuthActions = SetApiToken | Logout
