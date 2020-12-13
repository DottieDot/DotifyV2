
interface Alert {
  id: number
  message: string
  sevirity: 'error' | 'warning' | 'info' | 'success'
}

type AlertsState = { [id: number]: Alert }

export default AlertsState
