import { SetTheme, SET_THEME } from '../model/actions/Settings'

export const setTheme = (theme: SetTheme['theme']): SetTheme => ({
  type: SET_THEME,
  theme
})
