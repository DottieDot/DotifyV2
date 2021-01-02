import React, { ReactNode } from 'react'
import { makeStyles } from '@material-ui/core'

const useStyles = makeStyles(theme => ({
  grid: {
    display: 'grid',
    gap: theme.spacing(2),
    gridTemplateColumns: 'repeat(auto-fill, minmax(160px, 1fr))',
    marginTop: theme.spacing(),
    marginBottom: theme.spacing(2),
  }
}))

interface Props {
  children: ReactNode
}

export default ({ children }: Props) => {
  const classes = useStyles()

  return (
    <div className={classes.grid}>
      {children}
    </div>
  )
}
