import { Slide, useScrollTrigger } from '@material-ui/core'
import React, { ReactElement } from 'react'

interface Props {
  children: ReactElement
  threshold?: number
  disableHysteresis?: boolean
}

export default ({ children, threshold, disableHysteresis }: Props) => {
  const trigger = useScrollTrigger({ threshold, disableHysteresis })

  return (
    <Slide in={!trigger}>
      {children}
    </Slide>
  )
}

