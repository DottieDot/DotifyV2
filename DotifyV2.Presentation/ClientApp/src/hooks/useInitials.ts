import { useMemo } from 'react'
import getInitials from '../common/getInitials'

export default (str: string, count: number) => 
  useMemo(() => 
    getInitials(str, count), [str, count])
