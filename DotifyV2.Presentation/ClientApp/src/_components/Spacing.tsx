import { useTheme } from '@material-ui/core'
import React from 'react'

interface Props {
  direction?: 'horizontal' | 'vertical'
  size?: number
}

export default ({ direction = 'vertical', size = 1 }: Props) => {
  const theme = useTheme()

  return (
    <div 
      style={{
        height: direction === 'vertical'   ? theme.spacing(size) : 0,
        width : direction === 'horizontal' ? theme.spacing(size) : 0,
      }}
    />
  )
}
