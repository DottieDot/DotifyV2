import { useTypedSelector } from '../store'
import { AlertsState } from '../store/model/state'

export default (): AlertsState => 
  useTypedSelector(state => state.Alerts)
