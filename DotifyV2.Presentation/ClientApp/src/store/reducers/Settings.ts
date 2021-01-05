import { SettingsActions, SET_THEME } from '../model/actions/Settings'
import SettingsState from '../model/state/SettingsState'

const defaultState: SettingsState = {
  theme: 'system'
}

export default (state: SettingsState = defaultState, action: SettingsActions): SettingsState => {
  switch (action.type) {
    case SET_THEME:
      return {
        ...state,
        theme: action.theme
      }
    default:
      return state
  }
}
