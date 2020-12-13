import { useTypedSelector } from '../store'

export default (id: number) => 
  useTypedSelector(state => state.Alerts[id])
