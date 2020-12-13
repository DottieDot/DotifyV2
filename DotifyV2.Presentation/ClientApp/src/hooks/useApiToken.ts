import { useTypedSelector } from '../store'

export default () => 
  useTypedSelector(state => state.Auth.apiToken)
