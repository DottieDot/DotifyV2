import { RemoveAlert, REMOVE_ALERT, ShowAlert, SHOW_ALERT } from '../model/actions/Alerts'

export const showAlert = (message: string, severity: 'error' | 'warning' | 'info' | 'success'): ShowAlert => ({
  type: SHOW_ALERT,
  alert: {
    message,
    severity
  }
})

export const removeAlert = (alertId: number): RemoveAlert => ({
  type: REMOVE_ALERT,
  alertId
})
