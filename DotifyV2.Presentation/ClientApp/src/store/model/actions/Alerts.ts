
export const SHOW_ALERT = 'SHOW_ALERT'
export const REMOVE_ALERT = 'REMOVE_ALERT'

export interface ShowAlert {
  type: typeof SHOW_ALERT
  alert: {
    severity: 'error' | 'warning' | 'info' | 'success'
    message: string
  }
}

export interface RemoveAlert {
  type: typeof REMOVE_ALERT
  alertId: number
}

export type AlertsActions = ShowAlert | RemoveAlert
