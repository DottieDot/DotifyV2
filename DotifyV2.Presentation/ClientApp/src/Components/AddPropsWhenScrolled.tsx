import { useScrollTrigger } from '@material-ui/core'
import { cloneElement, ReactElement } from 'react'

interface Props {
  children: ReactElement
  threshold?: number
  props: any
}

export default ({ children, threshold = 0, props }: Props) => {
  const trigger = useScrollTrigger({
    disableHysteresis: true,
    threshold: threshold,
  })
  return cloneElement(children, trigger ?  props : {})
}
