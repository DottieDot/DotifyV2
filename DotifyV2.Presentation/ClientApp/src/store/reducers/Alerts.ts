import { AlertsActions, REMOVE_ALERT, SHOW_ALERT } from '../model/actions/Alerts'
import AlertsState from '../model/state/AlertsState'

let newId = 0

export default (state: AlertsState = {}, action: AlertsActions): AlertsState => {
  switch (action.type) {
    case SHOW_ALERT: 
      return {
        ...state,
        [++newId]: {
          id: newId,
          message: action.alert.message,
          sevirity: action.alert.severity
        }
      }
    case REMOVE_ALERT:
      return Object.keys(state)
        .reduce<AlertsState>((accumulator, id) => {
          if (+id !== action.alertId) {
            accumulator[+id] = state[+id]
          }
          return accumulator
        }, {})
    default:
      return state
  }
}
