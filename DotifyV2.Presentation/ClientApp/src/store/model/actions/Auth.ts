export const SET_API_TOKEN = 'SET_API_TOKEN'
export const CLEAR_API_TOKEN = 'CLEAR_API_TOKEN'

export interface SetApiToken {
  type: typeof SET_API_TOKEN
  apiToken: string
}

export interface ClearApiToken {
  type: typeof CLEAR_API_TOKEN
}

export type AuthActions = SetApiToken | ClearApiToken
