import { useTypedSelector } from '../store'

export default (): 'system' | 'dark' | 'light' => 
  useTypedSelector(state => state.Settings.theme)
