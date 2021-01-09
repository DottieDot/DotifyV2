import { useTypedSelector } from '../store'

export default () => 
  useTypedSelector(state => state.Settings.theme)
