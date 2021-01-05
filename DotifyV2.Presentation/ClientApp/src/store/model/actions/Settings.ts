
export const SET_THEME = 'SET_THEME'

export interface SetTheme {
  type: typeof SET_THEME
  theme: 'light' | 'dark' | 'system'
}

export type SettingsActions = SetTheme
